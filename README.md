# LHM-CppExport

* Exporter - C# Library that exposes functions that returns information as C# string's from [LibreHardwareMonitor](https://github.com/LibreHardwareMonitor/LibreHardwareMonitor)

* CPPdll - Managed C++ Library that exposes functions from Exporter and returns information as std::string's

* CppTest - Unmanaged C++ program that prints the returned strings from the functions in CPPdll to console

## To Create release DLL's and .lib

* LibreHardwareMonitor and other dependencies should be automatically installed with NuGet

1. Open solution with Visual Studio 2022

2. Set Release - x64

3. Build CPPdll

* For building btop4win LHM version, copy all ".dll" and ".lib" from "x64\Release" to "external" folder in top-level of [btop4win](https://github.com/aristocratos/btop4win).