namespace ServiceLayer
{
    public interface ICounterService
    {
        int GetNumberOfTextAppearance(string path, string searchTerm);
        string ExtractFileName(string path); 
    }
}
