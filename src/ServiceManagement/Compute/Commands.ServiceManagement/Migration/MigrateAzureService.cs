﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.HostedServices
{
    /// <summary>
    /// Migrate ASM deployment to ARM
    /// </summary>
    [Cmdlet(VerbsCommon.Move, "AzureService"), OutputType(typeof(OperationStatusResponse))]
    public class MigrateAzureServiceCommand : ServiceManagementBaseCmdlet
    {
        private const string AbortParameterSetName = "AbortMigrationParameterSet";
        private const string CommitParameterSetName = "CommitMigrationParameterSet";
        private const string PrepareDefaultParameterSetName = "PrepareDefaultMigrationParameterSet";
        private const string PrepareNewParameterSetName = "PrepareNewMigrationParameterSet";
        private const string PrepareExistingParameterSetName = "PrepareExistingMigrationParameterSet";

        private string DestinationVNetType;

        [Parameter(
            Position =0,
            Mandatory = true,
            ParameterSetName = AbortParameterSetName,
            HelpMessage = "Abort migration")]
        public SwitchParameter Abort
        {
            get;
            set;
        }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = CommitParameterSetName,
            HelpMessage = "Commit migration")]
        public SwitchParameter Commit
        {
            get;
            set;
        }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = PrepareDefaultParameterSetName,
            HelpMessage = "Prepare migration")]
        public SwitchParameter PrepareDefaultDestinationVNet
        {
            get;
            set;
        }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = PrepareNewParameterSetName,
            HelpMessage = "Prepare migration")]
        public SwitchParameter PrepreNewDestinationVNet
        {
            get;
            set;
        }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = PrepareExistingParameterSetName,
            HelpMessage = "Prepare migration")]
        public SwitchParameter PrepareExistingDestinationVNet
        {
            get;
            set;
        }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Service name.")]
        [ValidateNotNullOrEmpty]
        public string ServiceName
        {
            get;
            set;
        }

        [Parameter(
            Position = 2,
            Mandatory = true,
            HelpMessage = "Deployment name")]
        [ValidateNotNullOrEmpty]
        public string DeploymentName
        {
            get;
            set;
        }

        [Parameter(
            Position = 3,
            Mandatory = true,
            ParameterSetName = PrepareExistingParameterSetName,
            HelpMessage = "Deployment slot. Staging | Production (default Production)")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName
        {
            get;
            set;
        }

        [Parameter(
            Position = 4,
            Mandatory = true,
            ParameterSetName = PrepareExistingParameterSetName,
            HelpMessage = "Deployment slot. Staging | Production (default Production)")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkName
        {
            get;
            set;
        }

        [Parameter(
            Position = 5,
            Mandatory = true,
            ParameterSetName = PrepareExistingParameterSetName,
            HelpMessage = "Deployment slot. Staging | Production (default Production)")]
        [ValidateNotNullOrEmpty]
        public string SubnetName
        {
            get;
            set;
        }

        protected override void OnProcessRecord()
        {
            ServiceManagementProfile.Initialize();

            if (this.Abort.IsPresent)
            {
                ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => this.ComputeClient.Deployments.AbortMigration(this.ServiceName, DeploymentName));
            }
            else if (this.Commit.IsPresent)
            {
                ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => this.ComputeClient.Deployments.CommitMigration(this.ServiceName, DeploymentName));
            }
            else
            {
                if (this.PrepareDefaultDestinationVNet.IsPresent)
                {
                    DestinationVNetType =  DestinationVirtualNetwork.Default;
                }
                else if (this.PrepreNewDestinationVNet.IsPresent)
                {
                    DestinationVNetType = DestinationVirtualNetwork.New;
                }
                else
                {
                    DestinationVNetType = DestinationVirtualNetwork.Existing;
                }

                var parameter = (this.ParameterSetName == PrepareExistingParameterSetName)
                    ? new PrepareDeploymentMigrationParameters
                    {
                        DestinationVirtualNetwork = this.DestinationVNetType,
                        ResourceGroupName = this.ResourceGroupName,
                        SubNetName = this.SubnetName,
                        VirtualNetworkName = this.VirtualNetworkName
                    }
                    : new PrepareDeploymentMigrationParameters
                    {
                        DestinationVirtualNetwork = this.DestinationVNetType,
                        ResourceGroupName = string.Empty,
                        SubNetName = string.Empty,
                        VirtualNetworkName = string.Empty
                    };

                ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => this.ComputeClient.Deployments.PrepareMigration(this.ServiceName, DeploymentName, parameter));
            }
        }
    }
}
