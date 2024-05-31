using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

class MyJSONSerializer : MySerializer {
    public override T Read<T>(string filePath) {
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            JsonSerializerOptions options = new JsonSerializerOptions{
                WriteIndented =  true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
            };
            return JsonSerializer.Deserialize<T>(fs,options);
        }
        return default(T);
    }
    
    public override void Write<T>(T item, string filePath) {
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            JsonSerializerOptions options = new JsonSerializerOptions{
                WriteIndented =  true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
            };
            JsonSerializer.Serialize(fs, item,options);
        }
    }
}