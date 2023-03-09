using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMasterPage.Components.Services
{
    public interface IIDGenerator
    {
        string Generate { get; }
    }
}
