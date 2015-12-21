# Create class + namespace with folder if necessary
function makeclass($name) {
    $splitName = $name.split(@('.', '/', '\'))
    $dirName = "$([IO.Path]::Combine($splitName[0..($splitName.Length-2)]))"
    $className = "$($splitName[-1])"
    mkdir -force $dirName
    push-location $dirName
    yo aspnet:Class $className
    pop-location
}

