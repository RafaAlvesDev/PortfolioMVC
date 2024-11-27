// Mostrar a caixa de mensagem
function mostrarMensagem() {
    document.getElementById('myModal').style.display = 'block';
}

// Fechar a caixa de mensagem
function fecharMensagem() {
    document.getElementById('myModal').style.display = 'none';
}

// Fechar quando clicar fora da caixa
window.onclick = function (event) {
    if (event.target == document.getElementById('myModal')) {
        document.getElementById('myModal').style.display = 'none';
    }
}