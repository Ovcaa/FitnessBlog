using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessBlog.BaseLogic.Controller
{
    public abstract class ControllerBase
    {
        /// <summary>
        /// Сохранить данные.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        /// <param name="cl">Объект.</param>
        protected void Save(string path, object item)
        {
            var formatter = new BinaryFormatter();
            using(var file = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(file, item);
            }
        }

        /// <summary>
        /// Загрузить данные
        /// </summary>
        /// <typeparam name="T">Объект.</typeparam>
        /// <param name="path">Путь к файлу.</param>
        /// <returns></returns>
        protected T Load<T>(string path) 
        {
            var formatter = new BinaryFormatter();
            using (var file = new FileStream(path, FileMode.OpenOrCreate))
            {
                if (file.Length > 0 && formatter.Deserialize(file) is T items) return items;
                else return default(T);
            }
        }
    }
}
