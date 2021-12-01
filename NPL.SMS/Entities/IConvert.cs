
using System.Data;

namespace R2S.Training.Entities
{
    public interface IConvert
    {
        void ConvertToObject(DataRow dr);
    }
}
