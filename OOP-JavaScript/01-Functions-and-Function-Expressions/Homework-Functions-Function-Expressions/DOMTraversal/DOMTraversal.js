function traverse(classToCheckFor) {
	var checkStr = classToCheckFor.replace('.','');
	checkStr = checkStr.replace('s','');
	var reg = "\\S*"+checkStr+"\\S*\\w*";
  	traverseNode(document.documentElement, '');
	
	function traverseNode(node, spacing) {
		spacing = spacing || '';
		var spacingAddition = '';
		if (node.className !== "") {
			var id = node.id;
			var className = node.className;
			var pattern = new RegExp(reg);									
			if (pattern.test(className)) {
				spacingAddition = '  ';
				if (id !== "") {id = "id=" + node.id + " "; }
				if (className !== "") {className = "class=" + node.className; }

				console.log(spacing + ":" + 
				node.nodeName.toLowerCase() + " " +
				id + className);
			}
		}

		for (var i = 0, len = node.childNodes.length; i < len; i += 1) {
			var child = node.childNodes[i];
			if (child.nodeType === document.ELEMENT_NODE) {

				traverseNode(child, spacing + spacingAddition);
			}
		}
	}
}

var selector = ".birds";
traverse(selector);

