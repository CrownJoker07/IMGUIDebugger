# IMGUIDebugger

## 项目概述

`IMGUIDebugger` 是一个用于 Unity 游戏引擎的调试工具包，提供了丰富的调试窗口和功能，帮助开发者在开发过程中更高效地调试和监控游戏状态。  
基于<https://github.com/EllanJiang/UnityGameFramework>  框架中的Debugger 组件开发，将其从框架中独立为单独的插件，并添加新功能：
1. 调试按钮：支持按钮触发调试、显示调试状态、显示调试信息。
2. 调试信息：支持显示长内容调试信息
3. 自动适配各种分辨率屏幕，考虑上安全区域，是调试信息更易查看

## 安装和配置

### 安装

1. **通过 Unity Package Manager 安装**：
    - 打开 Unity 编辑器。
    - 进入 `Window` -> `Package Manager`。
    - 点击 `+` 按钮，选择 `Add package from git URL`。
    - 输入 `https://github.com/CrownJoker07/IMGUIDebugger.git` 的 Git 仓库地址并点击 `Add`。

2. **手动安装**：
    - 下载 `IMGUIDebugger` 的源代码。
    - 将下载的文件夹导入到 Unity 项目的 `Packages` 目录下。

## 使用指南

### 1. 设置调试按钮
```csharp
public readonly List<CommandData> CommandDatas = new List<CommandData>()
{
    // 单个调试按钮
    new CommandData()
    {
        Name = "调试 1",
        Action = (param) =>
        {
          // param 为参数
            Debug.Log($"调试 1:{param}");
        },
        State = () => true, // 调试状态，例如是否开启作弊等
        DebugType = (int)DebugType.Game, // 调试类型，用于分类
    }, 
}

```
```csharp
// 设置调试按钮
IMGUIDebugger.DebuggerComponent.SetCommandDatas(CommandDatas);
```

### 2. 设置调试信息
```csharp
  public readonly List<InfoData> InfoDatas = new List<InfoData>()
  {
      new InfoData()
      {
          Name = "调试信息名字",
          Info = () => "具体调试内容",
      },
  }
```
```csharp
// 设置调试信息
IMGUIDebugger.DebuggerComponent.SetInfoDatas(InfoDatas);
```

### 3. 激活调试
```csharp
IMGUIDebugger.DebuggerComponent.ActiveWindow = true;
```
     