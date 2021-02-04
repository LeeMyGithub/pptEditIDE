using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace jg.UpdateService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    //[ServiceContract]
    [ServiceContract(Namespace = "http://www.jingge.com/Mes")]
    public interface IUpdate
    {
        /// <summary>
        /// 获取应用程序最新版本号
        /// </summary>
        /// <param name="id">应用程序Id</param>
        /// <returns></returns>        
        [OperationContract]
        string[] GetVersion(Guid id);

        /// <summary>
        /// 获取应用程序更新文件包
        /// </summary>
        /// <param name="id">应用程序Id</param>
        /// <param name="From">开始流</param>
        /// <param name="To">结束流</param>
        /// <returns></returns>
        [OperationContract]
        byte[] GetFilePack(Guid id, long From);

        /// <summary>
        /// 获取应用程序更新包大小。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        long GetFileSize(Guid id);

        [OperationContract]
        string HelloWorld(string hello);
        /// <summary>
        /// 更新内容
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        
        string GetUpadateContent();
        /// <summary>
        /// 是否强制更新
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        bool GetIsForced();

    }

}
