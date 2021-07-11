const html = document.documentElement;
console.log(html);

const head = html.firstChild;
console.log(head);

const body = html.lastChild;
console.log(body);

const allChild = body.parentElement.childNodes;

console.log(allChild);

const button = document.getElementsByTagName('button');
console.log(button);

button[0].addEventListener('click', () => {
    button[0].style.color = 'blue';
    console.log('the button was click');
});