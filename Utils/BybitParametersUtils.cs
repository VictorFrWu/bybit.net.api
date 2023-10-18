namespace bybit.net.api
{
    public class BybitParametersUtils
    {
        public static void EnsureOnlyOneValidKey(Dictionary<string, object> parameters, string[] validKeys)
        {
            if (parameters == null)
            {
                return;
            }

            if (validKeys.Count(key => parameters.ContainsKey(key) && parameters[key] != null) > 1)
            {
                throw new ArgumentException("Only one of the following parameters is allowed: " + string.Join(", ", validKeys));
            }
        }
    }
}
