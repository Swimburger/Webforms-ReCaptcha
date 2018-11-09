using Newtonsoft.Json;
using System.Collections.Generic;

namespace ReCaptcha.Library
{
    public class ReCaptchaResponse
    {
        [JsonProperty("success")]
        public bool IsHuman { get; set; }

        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }
    }
}