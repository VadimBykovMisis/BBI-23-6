abstract public class MySerializer {
    public abstract T Read<T>(string filePath);
    public abstract void Write<T>(T item, string filePath);
}
