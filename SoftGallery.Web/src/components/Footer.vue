<template>
    <footer>
        <div class="footer_content">
            <div class="contacts">
                <h1>Logo</h1>
                <p>It´s all about your dreams</p>

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
                <li>
                    <h3>Blog</h3>
                </li>
                <li>
                    <a href="" class="footer-link">Tech</a>
                </li>
                  <li>
                    <a href="" class="footer-link">Adventures</a>
                </li>
                  <li>
                    <a href="" class="footer-link">Music</a>
                </li>
            </ul>
             <ul class="footer_list">
                <li>
                    <h3>Products</h3>
                </li>
                <li>
                    <a href="" class="footer-link">App</a>
                </li>
                  <li>
                    <a href="" class="footer-link">Desktop</a>
                </li>
                  <li>
                    <a href="" class="footer-link">Cloud</a>
                </li>
            </ul>
            <div class="footer_subscribe">
                <h3>Subscribe</h3>
                <p>
                    Subscribe to our newsletter to get the last news
                </p>
                
                <div class="input_group">
                    <input type="email" id="email">
                    <button>
                        <i class="fa-regular fa-envelope"></i>
                    </button>
                </div>
            </div>
        </div>
        <div id="footer_copyright">
            &#169
            2025 all rights reserved
        </div>
    </footer>

</template>
<script>
</script>
<style>
@import url('https://fonts.googleapis.com/css?family=Inter:wght@100;200;300;400;500;600&display=swap');

:root{
    --color-neutral-0: #0e0c0c;
    --color-neutral-10: #171717;
;   --color-neutral-30: #a8a29e;
    --color-neutral-40: #f5f5f5;
}
* {
    font-family: 'Inter,' sans-serif;
    margin: 0;
    padding: 0;
    box-sizing: border-box;
    letter-spacing: 1px;

}

footer{
    width: 100%;
    color: var( --color-neutral-40);
}

.footer-link {

}

.footer_content{
    background-color: var(--color-neutral-10);
    display: grid;
    grid-template-columns: repeat(4, 1fr);
    padding: 3rem 3.5rem;
}

.footer_contacts h1{
    margin-bottom: 0.7rem;
}

#footer_social_media{
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
    color: var( --color-neutral-40);
    border-radius: 50%;
    transition: all 0.4s;
}

#footer_social_media .footer-link:hover{
    font-weight: 1,25rem;
}
#footer_social_media .footer-link:hover {
    opacity: 0.8;

}
#instagram {
    background: linear-gradient(#7f37c9, #ff2992, #ff9807);
}

#facebook{
    background-color: #4267b3;
}

#whatsapp{
    background-color: #25d366;
}

.footer_link{
    text-decoration: dashed;
}
.footer_list{
    display: flex;
    flex-direction: column;
    gap: 0.75rem;
    list-style: none;
}

.footer_list .footer-link{
    color: var(--color-neutral-30);
    transition: all 0.4s;
}

.footer_list .footer-link:hover{
    color: #7f37c9
    
}

.footer_subscribe{
    display: flex;
    flex-direction: column;
    gap: 1.5rem
}

.footer_subscribe p{
    color: var(--color-neutral-30)
}

.input_group{
    display: flex;
    align-items: center;
    background-color: 4px;
    border-radius: 4px;
}

.input_group input{
    all: unset;
    padding: 0.75rem;
    width: 100%;

}

.input_group button {
    background-color: #7f37c9;
    border: none;
    color: var(--color-neutral-40);
    padding: 0px 1.25rem;
    font-size: 1.125rem;
    height: 100%;
    border-radius: 0px 4px 4px 0px;
    cursor: pointer;
    transition: all 0.4s;
}

.input_group button:hover{
    opacity: 0.8;
}

#fotter_copyright{
    display: flex;
    justify-content: center;
    background-color: var(--color-neutral-0);
    font-size: 0.9rem;
    padding: 1.5rem;
    font-weight: 100%;
}

@media screen and (max-width: 768px) {
    .footer_content{
        grid-template-columns: repeat(2, 1fr);
        gap: 2rem;
    }
}
@media screen and (max-width: 426px) {
    .footer_content{
        grid-template-columns: repeat(2, 1fr);
        gap: 2rem;
    }
}
</style>