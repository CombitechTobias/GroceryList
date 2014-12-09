String.Format = function () {
    var string = arguments[0];
    for (var i = 0; i < arguments.length - 1; i++) {
        var reg = new RegExp("\\{" + i + "\\}", "gm");
        string = string.replace(reg, arguments[i + 1]);
    }

    return string;
}

String.prototype.EndsWith = function (suffix) {
    return (this.substr(this.length - suffix.length) === suffix);
}

String.prototype.StartsWith = function (prefix) {
    return (this.substr(0, prefix.length) === prefix);
}