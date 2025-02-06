FROM nginx:latest

# SSL sertifikası için dizin oluştur
RUN mkdir -p /etc/nginx/ssl

# Cloudflare Origin Sertifikalarını Kopyala
COPY cloudflare-origin.pem /etc/nginx/ssl/cloudflare-origin.pem
COPY cloudflare-origin-key.pem /etc/nginx/ssl/cloudflare-origin-key.pem

# Dosya izinlerini güvenli hale getir
RUN chmod 600 /etc/nginx/ssl/cloudflare-origin-key.pem && \
    chmod 644 /etc/nginx/ssl/cloudflare-origin.pem

# Nginx konfigürasyon dosyasını kopyala
COPY nginx.conf /etc/nginx/nginx.conf
