### A referrence for CSS

Selector | Example | Example Description | CSS
---- | ---- | ----- | ----
.class | .intro | 	Selects all elements with class="intro" |	1
#id |	#firstname |	Selects the element with id="firstname"	| 1
*	| * |	Selects all elements	|  2
element |	p	| Selects all ``<p>`` elements |	1
element,element |	div, p |		Selects all `<div>` elements and all `<p>` elements |		1
element element |		div p |		Selects all `<p>` elements inside `<div>` elements |		1
element>element |		div > p	 |	Selects all `<p>` elements where the parent is a `<div>` element	 |	2
element+element	 |	div + p |		Selects all `<p>` elements that are placed immediately after `<div>` elements |		2
element1~element2 |		p ~ ul |		Selects every <ul> element that are preceded by a `<p>` element	 |	3
[attribute]	 |	[target] |		Selects all elements with a target attribute |		2
[attribute=value] |		[target=_blank]	 |	Selects all elements with target="_blank" |		2
[attribute~=value] |		[title~=flower]	 |	Selects all elements with a title attribute containing the word "flower"	 |	2
[attribute|=value] |		[lang|=en]	 |	Selects all elements with a lang attribute value starting with "en"	 |	2
[attribute^=value] |		a[href^="https"] |		Selects every `<a>` element whose href attribute value begins with "https" |		3
[attribute$=value] |		a[href$=".pdf"] |		Selects every `<a>` element whose href attribute value ends with ".pdf"	 |	3
[attribute`*`=value]  |		a[href*="w3schools"] |		Selects every `<a>` element whose href attribute value contains the substring "w3schools" |		3
:active |		a:active |		Selects the active link |		1
::after |		p::after	 |	Insert something after the content of each ``<p>`` element |		2
::before |		p::before |		Insert something before the content of each ``<p>`` element |		2
:checked |		input:checked	 |	Selects every checked `<input>` element	 |	3
:disabled |		input:disabled |		Selects every disabled `<input>` element |		3
:empty |		p:empty |		Selects every ``<p>`` element that has no children (including text nodes) |		3
:enabled |		input:enabled |		Selects every enabled `<input>` element	 |	3
:first-child |		p:first-child |		Selects every ``<p>`` element that is the first child of its parent	 |	2
::first-letter |		p::first-letter |		Selects the first letter of every ``<p>`` element	 |	1
::first-line |		p::first-line |		Selects the first line of every ``<p>`` element	 |	1
:first-of-type |		p:first-of-type |		Selects every ``<p>`` element that is the first ``<p>`` element of its parent	 |	3
:focus |		input:focus |		Selects the input element which has focus |		2
:hover |		a:hover |		Selects links on mouse over	 |	1
:in-range	 |	input:in-range |		Selects input elements with a value within a specified range |		3
:invalid |		input:invalid |		Selects all input elements with an invalid value	 |	3
:lang(language) |		p:lang(it) |		Selects every ``<p>`` element with a lang attribute equal to "it" (Italian) |		2
:last-child |		p:last-child |		Selects every ``<p>`` element that is the last child of its parent |		3
:last-of-type |		p:last-of-type |		Selects every ``<p>`` element that is the last ``<p>`` element of its parent |		3
:link |		a:link |		Selects all unvisited links |		1
:not(selector) |		:not(p) |		Selects every element that is not a `<p>` element	 |	3
:nth-child(n) |		p:nth-child(2) |		Selects every ``<p>`` element that is the second child of its parent |		3
:nth-last-child(n) |		p:nth-last-child(2) |		Selects every ``<p>`` element that is the second child of its parent, counting from the last child |		3
:nth-last-of-type(n) |		p:nth-last-of-type(2) |		Selects every ``<p>`` element that is the second ``<p>`` element of its parent, counting from the last child |		3
:nth-of-type(n) |		p:nth-of-type(2) |		Selects every `<p>` element that is the second ``<p>`` element of its parent |		3
:only-of-type |		p:only-of-type |		Selects every `<p>` element that is the only `<p>` element of its parent |		3
:only-child	 |	p:only-child	 |	Selects every `<p>` element that is the only child of its parent |		3
:optional	 |	input:optional |		Selects input elements with no "required" attribute |		3
:out-of-range |		input:out-of-range |		Selects input elements with a value outside a specified range	 |	3
:read-only |		input:read-only	 |	Selects input elements with the "readonly" attribute specified |		3
:read-write |		input:read-write |		Selects input elements with the "readonly" attribute NOT specified |		3
:required |		input:required |		Selects input elements with the "required" attribute specified |		3
:root	 |	:root	 |	Selects the document's root element	 |	3
::selection	 |	::selection	 |	Selects the portion of an element that is selected by a user |		 
:target |		#news:target |		Selects the current active #news element (clicked on a URL containing that anchor name) |		3
:valid |		input:valid	 |	Selects all input elements with a valid value |		3
:visited |		a:visited |		Selects all visited links |		1



### Color Properties

Property | Description | CSS
----- | ----- | ----- 
color | 	Sets the color of text | 1
opacity | 	Sets the opacity level for an element | 	3


### Background and Border Properties

Property | Description | CSS
----- | ----- | ----- 
background | 	A shorthand property for setting all the background properties in one declaration | 	1
background-attachment | 	Sets whether a background image is fixed or scrolls with the rest of the page | 	1
background-blend-mode | 	Specifies the blending mode of each background layer (color/image) | 	3 
background-color | 	Specifies the background color of an element | 	1
background-image | 	Specifies one or more background images for an element | 	1
background-position | 	Specifies the position of a background image | 	1
background-repeat | 	Sets how a background image will be repeated | 	1
background-clip | 	Specifies the painting area of the background	 | 3
background-origin | 	Specifies where the background image(s) is/are positioned	 | 3
background-size | 	Specifies the size of the background image(s)	 | 3
border | 	Sets all the border properties in one declaration	 | 1
border-bottom | 	Sets all the bottom border properties in one declaration | 	1
border-bottom-color	 | Sets the color of the bottom border	 | 1 
border-bottom-left-radius | 	Defines the shape of the border of the bottom-left corner | 	3
border-bottom-right-radius | 	Defines the shape of the border of the bottom-right corner | 	3
border-bottom-style	 | Sets the style of the bottom border	 | 1
border-bottom-width | 	Sets the width of the bottom border	 | 1
border-color | 	Sets the color of the four borders	 | 1
border-image | 	A shorthand property for setting all the border-image-* properties | 	3
border-image-outset | 	Specifies the amount by which the border image area extends beyond the border box	 | 3
border-image-repeat | 	Specifies whether the border image should be repeated, rounded or stretched | 	3
border-image-slice | 	Specifies how to slice the border image	 | 3
border-image-source	 | Specifies the path to the image to be used as a border | 	3
border-image-width | 	Specifies the widths of the image-border	 | 3
border-left | 	Sets all the left border properties in one declaration	 | 1
border-left-color | 	Sets the color of the left border	 | 1
border-left-style | 	Sets the style of the left border	 | 1
border-left-width | 	Sets the width of the left border	 | 1
border-radius | 	A shorthand property for setting all the four border-*-radius properties | 	3
border-right | 	Sets all the right border properties in one declaration | 	1
border-right-color | 	Sets the color of the right border | 	1
border-right-style | 	Sets the style of the right border | 	1
border-right-width | 	Sets the width of the right border | 	1
border-style | 	Sets the style of the four borders	 | 1
border-top	 | Sets all the top border properties in one declaration | 	1
border-top-color | 	Sets the color of the top border	 | 1
border-top-left-radius | 	Defines the shape of the border of the top-left corner | 	3
border-top-right-radius | 	Defines the shape of the border of the top-right corner	 | 3
border-top-style | 	Sets the style of the top border | 	1
border-top-width | 	Sets the width of the top border | 	1
border-width | 	Sets the width of the four borders | 	1
box-decoration-break | 	Sets the behaviour of the background and border of an element at page-break, or, for in-line elements, at line-break. | 	3
box-shadow | 	Attaches one or more drop-shadows to the box | 	3


### Basic Box Properties

Property | Description | CSS
----- | ----- | ----- 
bottom | 	Specifies the bottom position of a positioned element | 	2
clear | 	Specifies which sides of an element where other floating elements are not allowed | 	1
clip | 	Clips an absolutely positioned element	 | 2
display | 	Specifies how a certain HTML element should be displayed | 	1
float | 	Specifies whether or not a box should float	 | 1
height | 	Sets the height of an element | 	1
left | 	Specifies the left position of a positioned element | 	2
margin | 	Sets all the margin properties in one declaration | 	1
margin-bottom | 	Sets the bottom margin of an element	 | 1
margin-left | 	Sets the left margin of an element | 	1
margin-right | 	Sets the right margin of an element | 	1
margin-top | 	Sets the top margin of an element | 	1
max-height | 	Sets the maximum height of an element | 	2
max-width | 	Sets the maximum width of an element	 | 2
min-height | 	Sets the minimum height of an element	 | 2
min-width | 	Sets the minimum width of an element | 	2
overflow | Specifies what happens if content overflows an element's box	 | 2
overflow-x | 	Specifies whether or not to clip the left/right edges of the content, if it overflows the element's content area | 	3
overflow-y | 	Specifies whether or not to clip the top/bottom edges of the content, if it overflows the element's content area | 	3
padding | 	Sets all the padding properties in one declaration | 	1
padding-bottom | 	Sets the bottom padding of an element	 | 1
padding-left | 	Sets the left padding of an element	 | 1
padding-right | 	Sets the right padding of an element | 	1
padding-top	 | Sets the top padding of an element | 	1
position | 	Specifies the type of positioning method used for an element (static, relative, absolute or fixed) | 	2
right | 	Specifies the right position of a positioned element | 	2
top	 | Specifies the top position of a positioned element | 	2
visibility | 	Specifies whether or not an element is visible | 	2
width	 | Sets the width of an element | 	1
vertical-align | 	Sets the vertical alignment of an element | 	1
z-index	 | Sets the stack order of a positioned element | 	2


### Flexible Box Layout

Property | Description | CSS
----- | ----- | ----- 