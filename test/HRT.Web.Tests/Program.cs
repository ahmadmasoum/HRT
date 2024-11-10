using Microsoft.AspNetCore.Builder;
using HRT;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<HRTWebTestModule>();

public partial class Program
{
}
