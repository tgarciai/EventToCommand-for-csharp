using commands.com.tgi.ctoe;
namespace commands
{
    public class TestEventA : CommandEvent
    {

        public static string TYPE = "TEST_EVENT_A";
        public TestEventA(string type, object data = null) : base(type, data)
        {

        }


    }
}