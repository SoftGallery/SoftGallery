<template>
  <footer>
    <div class="footer_content">
      <div class="contacts">
        <h1>Logo</h1>
        <p class="SoftGallery">Soft Gallery</p>

        <div id="footer_social_media">
          <a href="#" class="footer-link" id="instagram">
            <i class="fa-brands fa-instagram"></i>
          </a>
          <a href="#" class="footer-link" id="facebook">
            <i class="fa-brands fa-facebook"></i>
          </a>
          <a href="#" class="footer-link" id="whatsapp">
            <i class="fa-brands fa-whatsapp"></i>
          </a>
        </div>
      </div>

      <ul class="footer_list">
        <li><h3>Paginas</h3></li>
        <li><a href="#novidades-section" class="footer-link">Novidades</a></li>
        <li><a href="#destaques" class="footer-link">Destaques</a></li>
        <li><a href="#categorias" class="footer-link">Categorias</a></li>
      </ul>

      <ul class="footer_list">
        <li><h3>Products</h3></li>
        <li><a href="#principal-container" class="footer-link">Ofertas</a></li>
        <li><a href="#colecao" class="footer-link">Coleção</a></li>
        <li><a href="#" class="footer-link">Cloud</a></li>
      </ul>
    </div>

    <div id="footer_copyright">
      &#169; 2025 all rights reserved
    </div>
  </footer>
</template>

<style>
@import url('https://fonts.googleapis.com/css?family=Inter:wght@100;200;300;400;500;600&display=swap');

:root {
  --color-neutral-0: #0e0c0c;
  --color-neutral-10: #171717;
  --color-neutral-30: #a8a29e;
  --color-neutral-40: #f5f5f5;
}

* {
  font-family: 'Inter', sans-serif;
  margin: 0;
  padding: 0;
  box-sizing: border-box;
  letter-spacing: 1px;
}

footer {
  width: 100%;
  color: var(--color-neutral-40);
}

.footer_content {
  background-color: var(--color-neutral-10);
  display: flex;
  justify-content: center; /* centraliza os 3 blocos */
  align-items: flex-start;
  gap: 4rem; /* espaço entre os blocos */
  padding: 3rem 3.5rem;
  flex-wrap: wrap;
}

.contacts,
.footer_list {
  flex: 0 1 200px; /* largura mínima com crescimento limitado */
  min-width: 200px;
}

.contacts h1 {
  margin-bottom: 0.7rem;
}

#footer_social_media {
  display: flex;
  gap: 2rem;
  margin-top: 1.5rem;
}

#footer_social_media .footer-link {
  display: flex;
  align-items: center;
  justify-content: center;
  height: 2.5rem;
  width: 2.5rem;
  color: var(--color-neutral-40);
  border-radius: 50%;
  transition: all 0.4s;
}

#footer_social_media .footer-link:hover {
  opacity: 0.8;
}

#instagram {
  background: linear-gradient(#7f37c9, #ff2992, #ff9807);
}

#facebook {
  background-color: #4267b3;
}

#whatsapp {
  background-color: #25d366;
}

.footer-link {
  text-decoration: none;
}

.footer_list {
  display: flex;
  flex-direction: column;
  gap: 0.75rem;
  list-style: none;
}

.footer_list .footer-link {
  color: var(--color-neutral-30);
  transition: all 0.4s;
}

.footer_list .footer-link:hover {
  color: #5f9fe9;
}

footer {
  margin-top: 40px; /* espaço entre o footer e a seção acima */
  width: 100%;
  color: var(--color-neutral-40);
}


#footer_copyright {
  display: flex;
  justify-content: center;
  background-color: var(--color-neutral-0);
  font-size: 0.9rem;
  padding: 1.5rem;
  font-weight: 100;
}

@media screen and (max-width: 768px) {
  .footer_content {
    flex-direction: column;
    align-items: center;
    text-align: center;
  }

  #footer_social_media {
    justify-content: center;
  }
}
.SoftGallery{
    color: #5f9fe9;
    font-size: 30px;
}
</style>
