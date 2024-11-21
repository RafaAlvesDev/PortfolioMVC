// Função para buscar os dados do perfil do GitHub
async function fetchGitHubProfile() {
    const username = "RafaAlvesDev"; // Substitua pelo seu nome de usuário no GitHub
    const url = `https://api.github.com/users/${username}`;

    try {
        const response = await fetch(url);

        // Verifica se a resposta é bem-sucedida
        if (!response.ok) {
            console.error("Erro ao buscar o perfil:", response.status, response.statusText);
            return;
        }

        const data = await response.json();

        // Seleciona os elementos HTML para exibir os dados
        const avatarImg = document.getElementById("github-avatar");
        const usernameText = document.getElementById("github-username");

        // Define o URL da imagem e o nome do usuário
        avatarImg.src = data.avatar_url;
        usernameText.textContent = `Usuário: ${data.login}`;
    } catch (error) {
        console.log("Erro ao buscar dados do GitHub:", error);
    }
}

// Chama a função quando o DOM estiver carregado
document.addEventListener("DOMContentLoaded", fetchGitHubProfile);
