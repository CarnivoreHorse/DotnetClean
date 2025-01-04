using System;
using System.IO;
using System.Linq;

namespace DotnetCleaner
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootDirectory = "C:\\Users\\ilpad\\Documents\\code";

            if (!Directory.Exists(rootDirectory))
            {
                Console.WriteLine("Directory does not exist. Exiting...");
                return;
            }

            Console.WriteLine($"Starting cleanup in: {rootDirectory}");

            // Define folders and extensions to clean
            string[] directoriesToDelete = { "bin", "obj", ".vs" };
            string[] fileExtensionsToDelete = { ".dll", ".exe", ".pdb", ".user", ".suo" };

            // Cleanup folders
            foreach (var folder in directoriesToDelete)
            {
                DeleteFolders(rootDirectory, folder);
            }

            // Cleanup files
            foreach (var extension in fileExtensionsToDelete)
            {
                DeleteFilesByExtension(rootDirectory, extension);
            }

            Console.WriteLine("Cleanup completed!");
        }

        static void DeleteFolders(string rootDirectory, string folderName)
        {
            var directories = Directory.GetDirectories(rootDirectory, folderName, SearchOption.AllDirectories);
            foreach (var directory in directories)
            {
                try
                {
                    Directory.Delete(directory, true);
                    Console.WriteLine($"Deleted folder: {directory}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to delete folder: {directory}. Error: {ex.Message}");
                }
            }
        }

        static void DeleteFilesByExtension(string rootDirectory, string extension)
        {
            var files = Directory.GetFiles(rootDirectory, $"*{extension}", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                try
                {
                    File.Delete(file);
                    Console.WriteLine($"Deleted file: {file}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to delete file: {file}. Error: {ex.Message}");
                }
            }
        }
    }
}

