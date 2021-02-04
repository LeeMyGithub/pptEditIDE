﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18408
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace jg.Editor.SecurityClientRemote {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SecurityClientRemote.IService", CallbackContract=typeof(jg.Editor.SecurityClientRemote.IServiceCallback))]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/TotalLicense", ReplyAction="http://tempuri.org/IService/TotalLicenseResponse")]
        int TotalLicense(System.Guid Key, System.Guid ModuleKey);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/CurrentLicense", ReplyAction="http://tempuri.org/IService/CurrentLicenseResponse")]
        int CurrentLicense(System.Guid Key, System.Guid ModuleKey);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Login", ReplyAction="http://tempuri.org/IService/LoginResponse")]
        string Login(string Code, string Password, System.Guid Key, System.Guid ModuleKey, string Message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Checked", ReplyAction="http://tempuri.org/IService/CheckedResponse")]
        bool Checked(string SessionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Activation", ReplyAction="http://tempuri.org/IService/ActivationResponse")]
        bool Activation(string request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/HelloWorld", ReplyAction="http://tempuri.org/IService/HelloWorldResponse")]
        string HelloWorld(string say);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/LogOff")]
        void LogOff(string code);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : jg.Editor.SecurityClientRemote.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.DuplexClientBase<jg.Editor.SecurityClientRemote.IService>, jg.Editor.SecurityClientRemote.IService {
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public int TotalLicense(System.Guid Key, System.Guid ModuleKey) {
            return base.Channel.TotalLicense(Key, ModuleKey);
        }
        
        public int CurrentLicense(System.Guid Key, System.Guid ModuleKey) {
            return base.Channel.CurrentLicense(Key, ModuleKey);
        }
        
        public string Login(string Code, string Password, System.Guid Key, System.Guid ModuleKey, string Message) {
            return base.Channel.Login(Code, Password, Key, ModuleKey, Message);
        }
        
        public bool Checked(string SessionId) {
            return base.Channel.Checked(SessionId);
        }
        
        public bool Activation(string request) {
            return base.Channel.Activation(request);
        }
        
        public string HelloWorld(string say) {
            return base.Channel.HelloWorld(say);
        }
    }
}
