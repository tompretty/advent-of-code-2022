using DaysLibrary;

namespace DaysLibraryTest;

[TestClass]
public class TestDay7
{
    [TestMethod]
    public void TestGetTotalSizeOfDirectoriesOfSizeLessThan100000()
    {
        var lines = new List<string> 
        {
            "$ cd /",
            "$ ls",
            "dir a",
            "14848514 b.txt",
            "8504156 c.dat",
            "dir d",
            "$ cd a",
            "$ ls",
            "dir e",
            "29116 f",
            "2557 g",
            "62596 h.lst",
            "$ cd e",
            "$ ls",
            "584 i",
            "$ cd ..",
            "$ cd ..",
            "$ cd d",
            "$ ls",
            "4060174 j",
            "8033020 d.log",
            "5626152 d.ext",
            "7214296 k",
        };

        var totalSize = Day7.GetTotalSizeOfDirectoriesOfSizeLessThan100000(lines);

        Assert.AreEqual(95437, totalSize);
    }

    [TestMethod]
    public void TestGetSizeOfSmallestDirectoryToDelete()
    {
        var lines = new List<string> 
        {
            "$ cd /",
            "$ ls",
            "dir a",
            "14848514 b.txt",
            "8504156 c.dat",
            "dir d",
            "$ cd a",
            "$ ls",
            "dir e",
            "29116 f",
            "2557 g",
            "62596 h.lst",
            "$ cd e",
            "$ ls",
            "584 i",
            "$ cd ..",
            "$ cd ..",
            "$ cd d",
            "$ ls",
            "4060174 j",
            "8033020 d.log",
            "5626152 d.ext",
            "7214296 k",
        };

        var size = Day7.GetSizeOfSmallestDirectoryToDelete(lines);

        Assert.AreEqual(24933642, size);
    }
}

[TestClass]
public class TestFileSystem
{
    [TestMethod]
    public void TestParseFromLinesWithSingleFile()
    {
        var lines = new List<string> 
        {
            "$ cd /",
            "$ ls",
            "100 foo.txt",
        };

        var fileSystem = Day7.FileSystem.ParseFromLines(lines);

        Assert.AreEqual(1, fileSystem.Root.Files.Count());
        Assert.AreEqual("foo.txt", fileSystem.Root.Files.ElementAt(0).Name);
        Assert.AreEqual(100, fileSystem.Root.Files.ElementAt(0).Size);
    }

    [TestMethod]
    public void TestParseFromLinesWithSingleFileWithoutExtension()
    {
        var lines = new List<string> 
        {
            "$ cd /",
            "$ ls",
            "100 foo",
        };

        var fileSystem = Day7.FileSystem.ParseFromLines(lines);

        Assert.AreEqual(1, fileSystem.Root.Files.Count());
        Assert.AreEqual("foo", fileSystem.Root.Files.ElementAt(0).Name);
        Assert.AreEqual(100, fileSystem.Root.Files.ElementAt(0).Size);
    }

    [TestMethod]
    public void TestParseFromLinesWithMultipleFiles()
    {
        var lines = new List<string> 
        {
            "$ cd /",
            "$ ls",
            "100 foo.txt",
            "150 foo.txt",
            "200 foo.txt",
        };

        var fileSystem = Day7.FileSystem.ParseFromLines(lines);

        Assert.AreEqual(3, fileSystem.Root.Files.Count());
    }

    [TestMethod]
    public void TestParseFromLinesWithSingleDirectory()
    {
        var lines = new List<string> 
        {
            "$ cd /",
            "$ ls",
            "dir foo",
        };

        var fileSystem = Day7.FileSystem.ParseFromLines(lines);

        Assert.AreEqual(1, fileSystem.Root.Directories.Count());
        Assert.AreEqual("foo", fileSystem.Root.Directories.ElementAt(0).Name);
    }

    [TestMethod]
    public void TestParseFromLinesWithCdIntoDirectory()
    {
        var lines = new List<string> 
        {
            "$ cd /",
            "$ ls",
            "dir foo",
            "$ cd foo",
            "$ ls",
            "100 bar.txt",
            "200 baz.txt",
        };

        var fileSystem = Day7.FileSystem.ParseFromLines(lines);

        Assert.AreEqual(1, fileSystem.Root.Directories.Count());
        Assert.AreEqual(2, fileSystem.Root.Directories.ElementAt(0).Files.Count());
    }

    [TestMethod]
    public void TestParseFromLinesWithCdOutOfDirectory()
    {
        var lines = new List<string> 
        {
            "$ cd /",
            "$ ls",
            "dir da",
            "dir db",
            "$ cd da",
            "$ ls",
            "100 fa.txt",
            "200 fb.txt",
            "$ cd ..",
            "$ cd db",
            "$ ls",
            "100 fc.txt",
        };

        var fileSystem = Day7.FileSystem.ParseFromLines(lines);

        Assert.AreEqual(2, fileSystem.Root.Directories.Count());
        Assert.AreEqual(2, fileSystem.Root.GetDirectory("da").Files.Count());
        Assert.AreEqual(1, fileSystem.Root.GetDirectory("db").Files.Count());
    }
}

[TestClass]
public class TestDirectory
{
    [TestMethod]
    public void TestGetSizesOfDirectories()
    {
        var root = new Day7.Directory("/");

        var da = new Day7.Directory("/");
        da.AddFile(new Day7.File("a.txt", 50));
        da.AddFile(new Day7.File("b.txt", 100));

        var db = new Day7.Directory("/");
        db.AddFile(new Day7.File("c.txt", 200));

        root.AddDirectory(da);
        root.AddDirectory(db);

        var sizes = new List<int>();
        root.GetSizesOfDirectories(sizes);

        Assert.AreEqual(150, sizes.ElementAt(0));
        Assert.AreEqual(200, sizes.ElementAt(1));
        Assert.AreEqual(350, sizes.ElementAt(2));
    }


    [TestMethod]
    public void TestAddFile()
    {
        var root = new Day7.Directory("/");
        var file = new Day7.File("foo", 100);

        root.AddFile(file);

        Assert.AreEqual(1, root.Files.Count());
        Assert.AreEqual(file, root.Files.ElementAt(0));
    }

    [TestMethod]
    public void TestAddDirectory()
    {
        var root = new Day7.Directory("/");
        var directory = new Day7.Directory("foo");

        root.AddDirectory(directory);

        Assert.AreEqual(1, root.Directories.Count());
        Assert.AreEqual(directory, root.Directories.ElementAt(0));
    }

    [TestMethod]
    public void TestGetDirectory()
    {
        var root = new Day7.Directory("/");
        var directory = new Day7.Directory("foo");

        root.AddDirectory(directory);

        var result = root.GetDirectory("foo");

        Assert.AreEqual(directory, result);
    }

}