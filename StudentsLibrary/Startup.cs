
using Microsoft.Owin;
using Owin;



[assembly: OwinStartup(typeof(StudentsLibrary.Startup))]

namespace StudentsLibrary
{
  public partial class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      ConfigureAuth(app);
    }

  }
}