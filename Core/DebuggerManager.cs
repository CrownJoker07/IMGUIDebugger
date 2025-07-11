﻿//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using UnityEngine;

namespace IMGUIDebugger
{
    /// <summary>
    /// 调试器管理器。
    /// </summary>
    internal sealed partial class DebuggerManager : IDebuggerManager
    {
        private readonly DebuggerWindowGroup m_DebuggerWindowRoot;
        private bool m_ActiveWindow;

        /// <summary>
        /// 初始化调试器管理器的新实例。
        /// </summary>
        public DebuggerManager()
        {
            m_DebuggerWindowRoot = new DebuggerWindowGroup();
            m_ActiveWindow = false;
        }

        /// <summary>
        /// 获取或设置调试器窗口是否激活。
        /// </summary>
        public bool ActiveWindow
        {
            get
            {
                return m_ActiveWindow;
            }
            set
            {
                m_ActiveWindow = value;
            }
        }

        /// <summary>
        /// 调试器窗口根结点。
        /// </summary>
        public IDebuggerWindowGroup DebuggerWindowRoot
        {
            get
            {
                return m_DebuggerWindowRoot;
            }
        }

        /// <summary>
        /// 调试器管理器轮询。
        /// </summary>
        /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位。</param>
        /// <param name="realElapseSeconds">真实流逝时间，以秒为单位。</param>
        internal void Update(float elapseSeconds, float realElapseSeconds)
        {
            if (!m_ActiveWindow)
            {
                return;
            }

            m_DebuggerWindowRoot.OnUpdate(elapseSeconds, realElapseSeconds);
        }

        /// <summary>
        /// 关闭并清理调试器管理器。
        /// </summary>
        internal void Shutdown()
        {
            m_ActiveWindow = false;
            m_DebuggerWindowRoot.Shutdown();
        }

        /// <summary>
        /// 注册调试器窗口。
        /// </summary>
        /// <param name="path">调试器窗口路径。</param>
        /// <param name="debuggerWindow">要注册的调试器窗口。</param>
        /// <param name="args">初始化调试器窗口参数。</param>
        public void RegisterDebuggerWindow(string path, IDebuggerWindow debuggerWindow, params object[] args)
        {
            if (string.IsNullOrEmpty(path))
            {
                Debug.LogError("Path is invalid.");
                return;
            }

            if (debuggerWindow == null)
            {
                Debug.LogError("Debugger window is invalid.");
                return;
            }

            m_DebuggerWindowRoot.RegisterDebuggerWindow(path, debuggerWindow);
            debuggerWindow.Initialize(args);
        }

        /// <summary>
        /// 解除注册调试器窗口。
        /// </summary>
        /// <param name="path">调试器窗口路径。</param>
        /// <returns>是否解除注册调试器窗口成功。</returns>
        public bool UnregisterDebuggerWindow(string path)
        {
            return m_DebuggerWindowRoot.UnregisterDebuggerWindow(path);
        }

        /// <summary>
        /// 获取调试器窗口。
        /// </summary>
        /// <param name="path">调试器窗口路径。</param>
        /// <returns>要获取的调试器窗口。</returns>
        public IDebuggerWindow GetDebuggerWindow(string path)
        {
            return m_DebuggerWindowRoot.GetDebuggerWindow(path);
        }

        /// <summary>
        /// 选中调试器窗口。
        /// </summary>
        /// <param name="path">调试器窗口路径。</param>
        /// <returns>是否成功选中调试器窗口。</returns>
        public bool SelectDebuggerWindow(string path)
        {
            return m_DebuggerWindowRoot.SelectDebuggerWindow(path);
        }
    }
}
