using System.Text.RegularExpressions;

namespace DaysLibrary;

public static class Day7
{
    public static int GetTotalSizeOfDirectoriesOfSizeLessThan100000(IEnumerable<string> lines)
    {
        var fileSystem = Day7.FileSystem.ParseFromLines(lines);

        var sizes = new List<int>();
        fileSystem.Root.GetSizesOfDirectories(sizes);

        return sizes
            .Select(s => s)
            .Where(s => s <= 100000)
            .Sum();
    }

    public static int GetSizeOfSmallestDirectoryToDelete(IEnumerable<string> lines)
    {
        var TOTAL_SPACE = 70000000;
        var TOTAL_REQUIRED_SPACE = 30000000;

        var fileSystem = Day7.FileSystem.ParseFromLines(lines);

        var sizes = new List<int>();

        var totalUsedSpace = fileSystem.Root.GetSizesOfDirectories(sizes);
        var remainingSpace = TOTAL_SPACE - totalUsedSpace;
        var requiredSpace = TOTAL_REQUIRED_SPACE - remainingSpace;

        return sizes
            .Select(s => s)
            .Where(s => s >= requiredSpace)
            .Min();
    }

    public class FileSystem 
    {
        public FileSystem(Directory root)
        {
            Root = root;
        }

        public static FileSystem ParseFromLines(IEnumerable<string> lines)
        {
            var root = new Directory("/");

            var directories = new Stack<Directory>();
            directories.Push(root);

            foreach (var line in lines.Skip(1))
            {
                var current = directories.Peek();

                if (IsFileLine(line))
                {
                    var file = ParseFile(line);
                    current.AddFile(file);
                }
                else if (IsDirectoryLine(line))
                {
                    var directory = ParseDirectory(line);
                    current.AddDirectory(directory);
                }
                else if (IsCdLine(line))
                {
                    var segments = line.Split(" ");

                    var name = segments.ElementAt(2);

                    if (name == "..")
                    {
                        directories.Pop();
                    }
                    else 
                    {
                        var directory = current.GetDirectory(name);

                        directories.Push(directory);
                    }
                }
            }

            return new FileSystem(root);
        }

        public static bool IsFileLine(string line)
        {
            var match = FILE_REGEX.Match(line);

            return match.Success;
        }

        public static File ParseFile(string line)
        {
            var segments = line.Trim().Split(" ");

            var name = segments.ElementAt(1);
            var size = int.Parse(segments.ElementAt(0));

            return new File(name, size);
        }

        public static bool IsDirectoryLine(string line)
        {
            var match = DIRECTORY_REGEX.Match(line);

            return match.Success;
        }

        public static Directory ParseDirectory(string line)
        {
            var segments = line.Trim().Split(" ");

            var name = segments.ElementAt(1);

            return new Directory(name);
        }

        public static bool IsCdLine(string line)
        {
            var match = CD_REGEX.Match(line);

            return match.Success;
        }

        public static Regex FILE_REGEX = new Regex(@"^[0-9]+ [a-z]+(\.[a-z]+)?$");
        public static Regex DIRECTORY_REGEX = new Regex(@"^dir [a-z]+$");
        public static Regex CD_REGEX = new Regex(@"^\$ cd ([a-z]+|\.\.)$");

        public Directory Root { get; }

    }

    public class Directory
    {
        public Directory(string name)
        {
            Name = name;
            Directories = new List<Directory>();
            Files = new List<File>();
        }

        public int GetSizesOfDirectories(List<int> accumulator)
        {
            var totalDirectoriesSize = Directories
                .Select(d => d.GetSizesOfDirectories(accumulator))
                .Sum();

            var totalFileSize = Files
                .Select(f => f.Size)
                .Sum();

            var size = totalDirectoriesSize + totalFileSize;

            accumulator.Add(size);

            return size;
        }

        public void AddFile(File file)
        {
            Files.Add(file);
        }

        public void AddDirectory(Directory directory)
        {
            Directories.Add(directory);
        }

        public Directory GetDirectory(string name)
        {
            return Directories
                .Select(d => d)
                .Where(d => d.Name == name)
                .First();
        }


        public string Name { get; }
        public List<Directory> Directories { get; }
        public List<File> Files { get; }
    }

    public class File 
    {
        public File(string name, int size)
        {
            Name = name;
            Size = size;
        }

        public string Name { get; }
        public int Size { get; }
    }
}