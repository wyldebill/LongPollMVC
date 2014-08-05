using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using LongPoll.Models;


namespace LongPoll.Controllers
{
    public class ChatController : Controller
    {


         static TaskCompletionSource<string> _nextMessage = new TaskCompletionSource<string>();

        //
        // GET: /Chat/

        public ActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public async Task<string> LongPoll()
        {
            string theMessage =  await _nextMessage.Task;

            return theMessage;
        }

        [HttpPost]
        public void PostMessage(string message)
        {
            _nextMessage.SetResult(message);
            _nextMessage = new TaskCompletionSource<string>();

        }

    }
}
