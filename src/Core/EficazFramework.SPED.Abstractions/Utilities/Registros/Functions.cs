﻿namespace EficazFramework.SPED.Utilities.Registros;
    
public static class Functions
{
    public static string ConvertStringArrayInDefaultSchema(params string[] data)
    {
        var schemaDefault = new StringBuilder();

        for (int i = 0; i < data.Length; i++)
        {
            if (i == 0)
            {
                schemaDefault.Append(data[i]);
                continue;
            }

            schemaDefault.Append("|" + data[i]);
        }

        return schemaDefault.ToString();
    }
}
