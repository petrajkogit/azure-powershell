namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Defines the load balancer resource settings.</summary>
    public partial class LoadBalancerResourceSettings
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ILoadBalancerResourceSettings.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ILoadBalancerResourceSettings.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ILoadBalancerResourceSettings FromJson(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject json ? new LoadBalancerResourceSettings(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject into a new instance of <see cref="LoadBalancerResourceSettings" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal LoadBalancerResourceSettings(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            __resourceSettings = new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ResourceSettings(json);
            {_backendAddressPool = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonArray>("backendAddressPools"), out var __jsonBackendAddressPools) ? If( __jsonBackendAddressPools as Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ILbBackendAddressPoolResourceSettings[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ILbBackendAddressPoolResourceSettings) (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.LbBackendAddressPoolResourceSettings.FromJson(__u) )) ))() : null : BackendAddressPool;}
            {_frontendIPConfiguration = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonArray>("frontendIPConfigurations"), out var __jsonFrontendIPConfigurations) ? If( __jsonFrontendIPConfigurations as Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ILbFrontendIpconfigurationResourceSettings[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ILbFrontendIpconfigurationResourceSettings) (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.LbFrontendIpconfigurationResourceSettings.FromJson(__p) )) ))() : null : FrontendIPConfiguration;}
            {_sku = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonString>("sku"), out var __jsonSku) ? (string)__jsonSku : (string)Sku;}
            {_zone = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonString>("zones"), out var __jsonZones) ? (string)__jsonZones : (string)Zone;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="LoadBalancerResourceSettings" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="LoadBalancerResourceSettings" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            __resourceSettings?.ToJson(container, serializationMode);
            if (null != this._backendAddressPool)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.XNodeArray();
                foreach( var __x in this._backendAddressPool )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("backendAddressPools",__w);
            }
            if (null != this._frontendIPConfiguration)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.XNodeArray();
                foreach( var __s in this._frontendIPConfiguration )
                {
                    AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                }
                container.Add("frontendIPConfigurations",__r);
            }
            AddIf( null != (((object)this._sku)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonString(this._sku.ToString()) : null, "sku" ,container.Add );
            AddIf( null != (((object)this._zone)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonString(this._zone.ToString()) : null, "zones" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}