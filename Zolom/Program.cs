using System;
using System.IO;
using System.Reflection;
using System.Text;
using IronPython.Hosting;
using IronPython.Modules;
using IronPython.Runtime;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace Zolom
{
    class Program
    {
        static void Main(string[] args)
        {
            string PyCode = args[0];
            ScriptEngine engine = Python.CreateEngine();
            Assembly ass = Assembly.GetExecutingAssembly();
            var sysScope = engine.GetSysModule();
            var importer = new ResourceMetaPathImporter(Assembly.GetExecutingAssembly(), "Lib.zip");
            List metaPath = (List)sysScope.GetVariable("meta_path");
            metaPath.Add(importer);
            sysScope.SetVariable("meta_path", metaPath);
            var script = engine.CreateScriptSourceFromString(PyCode, SourceCodeKind.Statements);
            script.Execute();
            Console.WriteLine("Finished Executing.");
        }
    }
}
