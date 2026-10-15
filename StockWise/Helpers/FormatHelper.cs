using System.Globalization;

namespace StockWise.Helpers;

/// <summary>Shared formatting helpers for the UI.</summary>
public static class FormatHelper
{
    private static readonly CultureInfo Chile = CultureInfo.GetCultureInfo("es-CL");

    /// <summary>Formats a decimal as Chilean pesos (e.g. $2.500).</summary>
    public static string CLP(decimal value) => value.ToString("C0", Chile);
}
