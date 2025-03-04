# ghidra decompile engine dev

> 根据Ghidra Build 文档, Windows下 反编译引擎只能使用MSVC编译       
> 可以先跟着 https://github.com/NationalSecurityAgency/ghidra 整体编译一遍      
> 笔者这里将 decompile代码单独拿出来，我对java端也不关心。  

> Ghidra Client 与 反编译引擎的关系类似  TeamServer 与 beacon的关系     
> 操作者通过GUI，下发任务,   decompile反编译引擎领取任务并返回结果。    
> 通信机制采用 匿名文件句柄  可以基于kernel32!Read/WriteFile  调试分析协议，源码也可以  

