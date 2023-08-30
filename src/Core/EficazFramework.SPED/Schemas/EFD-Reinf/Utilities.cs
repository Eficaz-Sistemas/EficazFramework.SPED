namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Utilitário para geração do identificador único de evento, para sua transmissão.
/// </summary>
public static class ReinfTimeStampUtils
{
    public static Dictionary<string, int> TimestampDict { get; private set; } = new Dictionary<string, int>();

    /// <summary>
    /// Gera uma string única para ser utilizada como identificar de um evento da EFD-Reinf.
    /// </summary>
    /// <returns></returns>
    public static string GetTimeStampIDForEvent()
    {
        int ID = 1;
        string timeString = string.Format("{0:yyyyMMddHHmmss}", DateTime.Now);
        if (TimestampDict.ContainsKey(timeString))
        {
            ID = TimestampDict[timeString] + 1;
            TimestampDict[timeString] = ID;
        }
        else
        {
            TimestampDict.Add(timeString, 1);
        }

        return string.Format("{0}{1:00000}", timeString, ID);
    }
}


/// <exclude/>
public abstract class EfdReinfBindableObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    protected void RaisePropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
