﻿using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace HRT.Pages;

[Collection(HRTTestConsts.CollectionDefinitionName)]
public class Index_Tests : HRTWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
