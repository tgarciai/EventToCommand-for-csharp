using commands.com.tgi.ctoe;
namespace commands
{
    public class TestEventB : CommandEvent
    {
        public static string TYPE = "TEST_EVENT_B";
        public TestEventB(string type, object data = null) : base(type, data)
        {

        }
    }
}
