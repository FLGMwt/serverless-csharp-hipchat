using System.Collections.Generic;
using Newtonsoft.Json;

namespace AwsDotnetCsharp
{
    public class Handler
    {
        public Response Hello(Request request)
        {
            var body = JsonConvert.DeserializeObject<Payload>(request.body);

            var from = body.item.message.from.mention_name;
            var room = body.item.room.name;

            return new Response(new
              {
                  color = "green",
                  message = $"Hello, {from} in {room}",
                  notify = false,
                  message_format = "text",
              });
        }
    }

    public class Request
    {
        public string body { get; set; }
    }

    public class Payload
    {
        public Item item { get; set; }
    }

    public class Item
    {
        public Message message { get; set; }
        public Room room { get; set; }
    }

    public class Room
    {
        public string name { get; set; }
    }

    public class Message
    {
        public From from { get; set; }
        public string message { get; set; }
    }

    public class From
    {
        public string name { get; set; }
        public string mention_name { get; set; }
    }

    public class Response
    {
        public Response(object body)
        {
            this.body = JsonConvert.SerializeObject(body);
        }
        public int statusCode { get; set; } = 200;
        public Dictionary<string, string> headers { get; set; } = new Dictionary<string, string>();
        public string body { get; set; }
    }
}

