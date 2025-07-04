GZ += static/cdn/jquery.min.js
static/cdn/jquery.min.js:
	$(CURL) $@ https://code.jquery.com/jquery-3.7.1.min.js
