using System;
using System.Net;
using Teambition.Finance;

namespace ConsoleApplication {
  public class Program {
    public static void Main(string[] args) {
      HttpApplication app = new HttpApplication();
      app.start();
    }
  }
}
