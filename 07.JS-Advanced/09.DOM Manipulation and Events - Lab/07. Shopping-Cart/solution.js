function solve() {
   let textAreaElement = document.querySelector('textarea');

   let uniqueProducts = [];

   document.querySelector('.shopping-cart').addEventListener('click', (e) => {
      if (e.target.tagName === 'BUTTON' && e.target.className === 'add-product') {
         const productName = e.target.parentNode.parentNode.querySelector('.product-title').textContent;
         const productPrice = Number(e.target.parentNode.parentNode.querySelector('.product-line-price').textContent);

         uniqueProducts.push({ productName, productPrice });

         textAreaElement.value += `Added ${productName} for ${(productPrice).toFixed(2)} to the cart.\n`;
      }
   });

   document.querySelector('.checkout').addEventListener('click', (e) => {
      const result = uniqueProducts.reduce((acc, c) => {
         acc.products.push(c.productName);
         acc.totalPrice += c.productPrice;
         return acc;
      }, {products: [], totalPrice: 0});

      textAreaElement.value += `You bought ${result.products.join(', ')} for ${result.totalPrice.toFixed(2)}.`;

      Array.from(document.querySelectorAll('button')).forEach(b => b.disabled = true);
   });
}