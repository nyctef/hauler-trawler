# TODO: pull default namespace from project.json

# Create class + namespace with folder if necessary
function makecsfile($name, $baseDir, $baseNamespace, $template) {
    $dirPath = $baseDir
    $className = $name
    $namespace = $baseNamespace

    $splitName = $name.split(@('.'))
    if ($splitName.length -gt 1) {
        $dirName = "$([IO.Path]::Combine($splitName[0..($splitName.Length-2)]))"
        $className = "$($splitName[-1])"
        $namespace = $baseNamespace + "." + [string]::join('.', $splitName, 0, $splitName.Length-1)
        $dirPath = "$PSScriptRoot/src/HaulerTrawler/$dirName"
        write-output "making sure $dirPath exists"
        mkdir -force $dirPath | out-null
    }

    write-output "className: $className namespace: $namespace"
    write-output "switching to $dirPath"
    push-location $dirPath

    write-output "writing out to $($className).cs"
    $ExecutionContext.InvokeCommand.ExpandString($template) |
        out-file "$($className).cs"

    pop-location
}

function makeclass($name) {
    makecsfile $name "$PSScriptRoot/src/HaulerTrawler" 'HaulerTrawler' 'using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaulerTrawler.Interfaces;
using HaulerTrawler.Eve;
using HaulerTrawler.Utils;

namespace $namespace
{
    public class $className : I$className
    {
        public $className()
        {
        }
    }
}
'
}


function makeinterface($name) {
    makecsfile $name "$PSScriptRoot/src/HaulerTrawler" 'HaulerTrawler' 'using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaulerTrawler.Interfaces;
using HaulerTrawler.Eve;
using HaulerTrawler.Utils;

namespace $namespace
{
    public interface $className
    {
    }
}
'
}

function maketest($name) {
    makecsfile $name "$PSScriptRoot/tests/HaulerTrawler.Tests" 'HaulerTrawler.Tests' 'using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;
using HaulerTrawler.Interfaces;
using HaulerTrawler.Eve;
using HaulerTrawler.Utils;
using FluentAssertions;

namespace $namespace
{
    public class $className
    {
        [Fact]
        public void ShouldDoAThing_AndThenDoAnotherThing() 
        {
            throw new NotImplementedException();
        }
    }
}
'
}
