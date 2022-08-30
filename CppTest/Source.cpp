/*
    Example project for how to import C# functions from Exporter (C#) via CPPdll (Managed C++) to CppTest (Unmanaged C++)
*/
#include <iostream>
#include <string>
#pragma comment(lib, "..\\x64\\Release\\CPPdll.lib")

_declspec(dllexport) std::string FetchLHMValues();
_declspec(dllexport) std::string FetchLHMReport();

int main()
{
    std::cout << FetchLHMReport();
    std::cout << FetchLHMValues();
}
