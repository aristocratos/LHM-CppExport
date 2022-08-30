#include <iostream>
#include <string>
#include <msclr\marshal_cppstd.h>

using namespace System;
using namespace System::Reflection;
using namespace Exporter;

namespace Importer {
    public ref class DoWork {
    public:String^ GetSystem() {
        return ExportClass::Export();
    }
    public:String^ GetSystemReport() {
        return ExportClass::ExportReport();
    }
    };

    std::string fetch() {
        DoWork work;
        msclr::interop::marshal_context context;
        return context.marshal_as<std::string>(work.GetSystem());
    }

    std::string fetchReport() {
        DoWork work;
        msclr::interop::marshal_context context;
        return context.marshal_as<std::string>(work.GetSystemReport());
    }
}

__declspec(dllexport) std::string FetchLHMValues() {
    return Importer::fetch();
}

__declspec(dllexport) std::string FetchLHMReport() {
    return Importer::fetchReport();
}