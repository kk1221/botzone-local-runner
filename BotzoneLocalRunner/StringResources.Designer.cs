﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace BotzoneLocalRunner {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class StringResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal StringResources() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BotzoneLocalRunner.StringResources", typeof(StringResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   使用此强类型资源类，为所有资源查找
        ///   重写当前线程的 CurrentUICulture 属性。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查找类似 复制的URL无效 的本地化字符串。
        /// </summary>
        internal static string BAD_LOCALAI_URL {
            get {
                return ResourceManager.GetString("BAD_LOCALAI_URL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 https://www.botzone.org/api/ 的本地化字符串。
        /// </summary>
        internal static string BOTZONE_API_BASE {
            get {
                return ResourceManager.GetString("BOTZONE_API_BASE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 &lt;请在这里输入Bot的ID&gt; 的本地化字符串。
        /// </summary>
        internal static string BOTZONEBOT_PLACEHOLDER {
            get {
                return ResourceManager.GetString("BOTZONEBOT_PLACEHOLDER", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 玩家ID不可为空 的本地化字符串。
        /// </summary>
        internal static string ID_EMPTY {
            get {
                return ResourceManager.GetString("ID_EMPTY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 &lt;请使用选择按钮选择程序&gt; 的本地化字符串。
        /// </summary>
        internal static string LOCALAI_PLACEHOLDER {
            get {
                return ResourceManager.GetString("LOCALAI_PLACEHOLDER", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 &lt;开启对局后在右侧展示画面操作&gt; 的本地化字符串。
        /// </summary>
        internal static string LOCALHUMAN_PLACEHOLDER {
            get {
                return ResourceManager.GetString("LOCALHUMAN_PLACEHOLDER", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 所有程序 (*.exe;*.py;*.js;Main.class)|*.exe;*.py;*.js;*.class|Python 代码 (*.py)|*.py|Node.js 代码 (*.js)|*.js|Java 主类文件 |Main.class 的本地化字符串。
        /// </summary>
        internal static string OFD_FILTER {
            get {
                return ResourceManager.GetString("OFD_FILTER", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 选择要运行的本地AI程序 的本地化字符串。
        /// </summary>
        internal static string OFD_TITLE {
            get {
                return ResourceManager.GetString("OFD_TITLE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Botzone上的AI只可以有0个或{0}个 的本地化字符串。
        /// </summary>
        internal static string WRONG_BOTZONE_AI_COUNT {
            get {
                return ResourceManager.GetString("WRONG_BOTZONE_AI_COUNT", resourceCulture);
            }
        }
    }
}
