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
            string PyCode = "";
            if (args.Length >= 1)
            {
                switch (args[0].Split(':')[0].ToLower())
                {
                    case "--b64script":
                        {
                            byte[] ScriptBytes = Convert.FromBase64String(args[0].Split(':')[1]);
                            PyCode = Encoding.ASCII.GetString(ScriptBytes);
                            break;
                        }
                    case "--script":
                        {
                            PyCode = args[0].Split(':')[1];
                            break;
                        }
                    default:
                        {
                            PrintUsage();
                            return;
                        }
                }
            }
            else
            {
                PrintUsage();
                return;
            }
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
        static void PrintUsage()
        {
            Console.WriteLine("Usage: zolom.exe --script:\"print 'hello world'\"");
            Console.WriteLine("Usage: zolom.exe --b64script:cHJpbnQgImhlbGxvIHdvcmxkIg==");
        }
    }

}
