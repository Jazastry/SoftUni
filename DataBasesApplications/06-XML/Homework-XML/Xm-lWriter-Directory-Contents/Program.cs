using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;

namespace Xm_lWriter_Directory_Contents
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = false;
            XmlWriter writer = XmlWriter.Create("directory-traversal.xml", settings);
            writer.WriteStartElement("root-dir");
            writer.WriteAttributeString("name", "Homework-XML");

            var root = Directory.GetDirectories(@"C:\Users\Jazzy\Documents\Visual Studio 2013\Projects\Homework-XML");
            foreach (var directory in root)
            {
                System.IO.DirectoryInfo diectory = new DirectoryInfo(directory);
                string directoryName = new DirectoryInfo(directory).Name;   
        
                writer.WriteStartElement("dir");
                writer.WriteAttributeString("name", directoryName);

                WalkDirectoryTree(diectory, writer);

                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        public static void WalkDirectoryTree(System.IO.DirectoryInfo root, XmlWriter writer)
        {  
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;

            // First, process all the files directly under this folder 
            try
            {
                files = root.GetFiles("*.*");
                writer.WriteStartElement("dir");
                writer.WriteAttributeString("name", root.Name);
            }
            // This is thrown if even one of the files requires permissions greater 
            // than the application provides. 
            catch (UnauthorizedAccessException e)
            {
                // This code just writes out the message and continues to recurse. 
                // You may decide to do something different here. For example, you 
                // can try to elevate your privileges and access the file again.
               // log.Add(e.Message);
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                //Console.WriteLine(e.Message);
            }

            if (files != null)
            {
                foreach (System.IO.FileInfo fi in files)
                {
                    // In this example, we only access the existing FileInfo object. If we 
                    // want to open, delete or modify the file, then 
                    // a try-catch block is required here to handle the case 
                    // where the file has been deleted since the call to TraverseTree().
                    writer.WriteStartElement("file");
                    writer.WriteAttributeString("name", fi.Name);
                    writer.WriteEndElement();
                }

                // Now find all the subdirectories under this directory.
                subDirs = root.GetDirectories();

                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    // Resursive call for each subdirectory.
                    WalkDirectoryTree(dirInfo, writer);                    
                }                
            }
            writer.WriteEndElement();
        }
    }
}
