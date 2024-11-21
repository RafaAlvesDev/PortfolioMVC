let eleScroll = document.querySelector('.scroll');
let eleContainer = document.querySelector('.scroll__container');
let eleItem = Array.from(eleContainer.children);

eleItem.forEach(item => {
    let eleDuplicado = item.cloneNode(true);
    eleDuplicado.setAttribute('aria-hidden', true);

    eleContainer.appendChild(eleDuplicado);
});
