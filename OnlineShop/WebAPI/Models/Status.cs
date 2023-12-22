using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using WebAPI.Helpers;

namespace WebAPI.Models
{
    [JsonConverter(typeof(JsonStringEnumConverterEx<Status>))]
    public enum Status
    {
        [EnumMember(Value = "Не установлен")]
        None = 0,
        [EnumMember(Value = "Актуальный")]
        Actual = 1,
        [EnumMember(Value = "Удален")]
        Deleted = 2
    }
}
