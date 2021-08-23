﻿using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualGymWebPage
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.sendChat(name, message);
        }
    }
}