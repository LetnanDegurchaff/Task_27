namespace WinFormsApp1.Exceptions;

public class FileNotFoundException : Exception
{
    public FileNotFoundException(string filePath)
    {
        if (filePath == null!)
            FilePath = string.Empty;

        FilePath = filePath!;
    }
    
    public string FilePath { get; }
}