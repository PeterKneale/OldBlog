using Castle.Components.DictionaryAdapter;

namespace Gallery.Core
{
    public interface ISettings
    {
        [Component]
        IClientSettings Client { get; set; }
    }

    public interface IClientSettings
    {
        string ClientId { get; set; }
        string ClientSecret { get; set; }
        string EndPoint { get; set; }
    }
}