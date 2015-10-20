if("undefined"==typeof Zepto)throw new Error("Parallax.js's JavaScript requires Zepto");!function(a){"use strict";function r(){p=h.length,b=a(window).width(),m=a(window).height();for(var r=0;p>r;r++)a(h[r]).attr("data-id",r+1);g.loading||(a(h[v]).addClass("current"),g.callback(v,h[v])),k.addClass(g.direction).addClass(g.swipeAnim),h.css({width:b+"px",height:m+"px"}),"horizontal"===g.direction?k.css("width",b*h.length):k.css("height",m*h.length),("cover"===g.swipeAnim||"victoria"===g.swipeAnim)&&(k.css({width:b,height:m}),h[0].style.display="block"),g.indicator||g.loading?(a(".wrapper").append('<div class="helper"></div>'),g.loading&&a(".helper").append('<div class="h-loading"><i class="ui-loading ui-loading-white"></i></div>')):C=!1}function s(a){return C===!0?(event.preventDefault(),!1):(u=!0,l="horizontal"===g.direction?a.pageX:a.pageY,"default"===g.swipeAnim&&(k.addClass("drag"),f=k.css("-webkit-transform").replace("matrix(","").replace(")","").split(","),f="horizontal"===g.direction?parseInt(f[4]):parseInt(f[5])),("cover"===g.swipeAnim&&g.drag||"victoria"===g.swipeAnim&&g.drag)&&h.addClass("drag"),w=1,void 0)}function e(a){return C===!0||u===!1?(event.preventDefault(),!1):(event.preventDefault(),c="horizontal"===g.direction?a.pageX:a.pageY,d(),g.drag&&!o()&&i(),w=2,void 0)}function t(r){C===!0||2!==w||(u=!1,c="horizontal"===g.direction?r.pageX:r.pageY,"default"!==g.swipeAnim||o()?"cover"!==g.swipeAnim||o()?"victoria"!==g.swipeAnim||o()||(Math.abs(c-l)<=50&&c>=l&&g.drag?n(v,"keep-backward"):Math.abs(c-l)<=50&&l>c&&g.drag?n(v,"keep-forward"):Math.abs(c-l)>50&&c>=l&&g.drag?n(v-1,"backward"):Math.abs(c-l)>50&&l>c&&g.drag?n(v+1,"forward"):Math.abs(c-l)>50&&c>=l&&!g.drag?n(v-1,"backward"):Math.abs(c-l)>50&&l>c&&!g.drag&&n(v+1,"forward")):Math.abs(c-l)<=50&&c>=l&&g.drag?n(v,"keep-backward"):Math.abs(c-l)<=50&&l>c&&g.drag?n(v,"keep-forward"):Math.abs(c-l)>50&&c>=l&&g.drag?n(v-1,"backward"):Math.abs(c-l)>50&&l>c&&g.drag?n(v+1,"forward"):Math.abs(c-l)>50&&c>=l&&!g.drag?n(v-1,"backward"):Math.abs(c-l)>50&&l>c&&!g.drag&&n(v+1,"forward"):(k.removeClass("drag"),Math.abs(c-l)<=50?n(v):c>=l?n(v-1):l>c&&n(v+1)),g.indicator&&a(a(".h-indicator ul li").removeClass("current").get(v)).addClass("current"),w=3)}function i(){if("default"===g.swipeAnim){var r=f+c-l;"horizontal"===g.direction?k.css("-webkit-transform","matrix(1, 0, 0, 1, "+r+", 0)"):k.css("-webkit-transform","matrix(1, 0, 0, 1, 0, "+r+")")}else if("cover"===g.swipeAnim){var r=c-l,s=a(h[v-1]),e=a(h[v+1]);a(h).css({"z-index":0}),"horizontal"===g.direction&&c>=l?s.css({"z-index":2,display:"block","-webkit-transform":"translate3d("+(r-b)+"px, 0 ,0)"}):"horizontal"===g.direction&&l>c?e.css({"z-index":2,display:"block","-webkit-transform":"translate3d("+(b+r)+"px, 0, 0)"}):"vertical"===g.direction&&c>=l?s.css({"z-index":2,display:"block","-webkit-transform":"translate3d(0,"+(r-m)+"px ,0)"}):"vertical"===g.direction&&l>c&&e.css({"z-index":2,display:"block","-webkit-transform":"translate3d(0,"+(m+r)+"px ,0)"})}else if("victoria"===g.swipeAnim){var r=c-l,s=a(h[v-1]),t=a(h[v]),e=a(h[v+1]);a(h).css({"z-index":0}),"horizontal"===g.direction&&c>=l?(t.css({"-webkit-transform":"translate3d("+r/10+"px,0,0) scale("+(1-Math.abs(r/(b/20))/100)+")"}),s.css({"z-index":2,display:"block","-webkit-transform":"translate3d("+(r-b)+"px,0,0)"})):"horizontal"===g.direction&&l>c?(t.css({"-webkit-transform":"translate3d("+r/10+"px,0,0) scale("+(1-Math.abs(r/(b/20))/100)+")"}),e.css({"z-index":2,display:"block","-webkit-transform":"translate3d("+(b+r)+"px,0,0)"})):"vertical"===g.direction&&c>=l?(t.css({"-webkit-transform":"translate3d(0,"+r/10+"px,0) scale("+(1-Math.abs(r/(m/20))/100)+")"}),s.css({"z-index":2,display:"block","-webkit-transform":"translate3d(0,"+(r-m)+"px ,0)"})):"vertical"===g.direction&&l>c&&(t.css({"-webkit-transform":"translate3d(0,"+r/10+"px,0) scale("+(1-Math.abs(r/(m/20))/100)+")"}),e.css({"z-index":2,display:"block","-webkit-transform":"translate3d(0,"+(m+r)+"px ,0)"}))}}function n(r,s){if(v=r,"default"===g.swipeAnim){var e=0;e="horizontal"===g.direction?r*-b:r*-m,"horizontal"===g.direction?k.css({"-webkit-transform":"matrix(1, 0, 0, 1, "+e+", 0)"}):k.css({"-webkit-transform":"matrix(1, 0, 0, 1, 0, "+e+")"})}else"cover"===g.swipeAnim?"keep-backward"===s&&g.drag?(h.removeClass("drag"),"horizontal"===g.direction?a(h[v-1]).css({"-webkit-transform":"translate3d(-100%, 0, 0)"}):a(h[v-1]).css({"-webkit-transform":"translate3d(0, -100%, 0)"})):"keep-forward"===s&&g.drag?(h.removeClass("drag"),"horizontal"===g.direction?a(h[v+1]).css({"-webkit-transform":"translate3d(100%, 0, 0)"}):a(h[v+1]).css({"-webkit-transform":"translate3d(0, 100%, 0)"})):"forward"===s&&g.drag?(h.removeClass("drag"),a(h[v-1]).addClass("back"),h[v].style.webkitTransform="translate3d(0, 0, 0)"):"backward"===s&&g.drag?(h.removeClass("drag"),a(h[v+1]).addClass("back"),h[v].style.webkitTransform="translate3d(0, 0, 0)"):"forward"!==s||g.drag?"backward"!==s||g.drag||(k.addClass("animate"),a(h[v+1]).addClass("back"),a(h[v]).addClass("front").show()):(k.addClass("animate"),a(h[v-1]).addClass("back"),a(h[v]).addClass("front").show()):"victoria"===g.swipeAnim&&("keep-backward"===s&&g.drag?(h.removeClass("drag"),a(h[v]).css({"-webkit-transform":"translate3d(0, 0, 0) scale(1)"}),"horizontal"===g.direction?a(h[v-1]).css({"-webkit-transform":"translate3d(-100%, 0, 0)"}):a(h[v-1]).css({"-webkit-transform":"translate3d(0, -100%, 0)"})):"keep-forward"===s&&g.drag?(h.removeClass("drag"),a(h[v]).css({"-webkit-transform":"translate3d(0, 0, 0) scale(1)"}),"horizontal"===g.direction?a(h[v+1]).css({"-webkit-transform":"translate3d(100%, 0, 0)"}):a(h[v+1]).css({"-webkit-transform":"translate3d(0, 100%, 0)"})):"forward"===s&&g.drag?(h.removeClass("drag"),a(h[v-1]).addClass("back"),h[v].style.webkitTransform="translate3d(0, 0, 0)",h[v-1].style.webkitTransform="horizontal"===g.direction?"translate3d(-60px, 0, 0) scale(0.8)":"translate3d(0, -60px, 0) scale(0.8)"):"backward"===s&&g.drag?(h.removeClass("drag"),a(h[v+1]).addClass("back"),h[v].style.webkitTransform="translate3d(0, 0, 0)",h[v+1].style.webkitTransform="horizontal"===g.direction?"translate3d(60px, 0, 0) scale(0.8)":"translate3d(0, 60px, 0) scale(0.8)"):"forward"!==s||g.drag?"backward"!==s||g.drag||(k.addClass("animate"),a(h[v+1]).addClass("back"),a(h[v]).addClass("front").show()):(k.addClass("animate"),a(h[v-1]).addClass("back"),a(h[v]).addClass("front").show()));C=!0,setTimeout(function(){C=!1},300)}function d(){"horizontal"===g.direction?c>=l?k.removeClass("forward").addClass("backward"):l>c&&k.removeClass("backward").addClass("forward"):c>=l?k.removeClass("forward").addClass("backward"):l>c&&k.removeClass("backward").addClass("forward")}function o(){if("horizontal"===g.direction){if(c>=l&&0===v||l>=c&&v===p-1)return!0}else if(c>=l&&0===v||l>=c&&v===p-1)return!0;return!1}var l,c,w,f,p,b,m,k,h,g,v=0,u=!1,C=!0;a.fn.parallax=function(s){return g=a.extend({},a.fn.parallax.defaults,s),this.each(function(){k=a(this),h=k.find(".page"),r()})},a.fn.parallax.defaults={direction:"vertical",swipeAnim:"default",drag:!0,loading:!1,indicator:!1,arrow:!1,callback:function(){}},a(document).on("touchstart",".page",function(a){s(a.changedTouches[0])}).on("touchmove",".page",function(a){e(a.changedTouches[0])}).on("touchend",".page",function(a){t(a.changedTouches[0])}).on("webkitAnimationEnd webkitTransitionEnd",".pages",function(){setTimeout(function(){a(".back").hide().removeClass("back"),a(".front").show().removeClass("front"),k.removeClass("forward backward"),k.removeClass("animate")},10),a(h.removeClass("current").get(v)).addClass("current"),g.callback(v,h[v])}),a(".page *").on("webkitAnimationEnd",function(){event.stopPropagation()}),a(window).on("load",function(){if(g.loading&&(a(".h-loading").remove(),a(".helper").remove(),C=!1,a(h[v]).addClass("current"),g.callback(v,h[v])),g.indicator){C=!1,a(".helper").append('<div class="h-indicator"></div>');for(var r="<ul>",s=1;p>=s;s++)r+=1===s?'<li class="current">'+s+"</li>":"<li>"+s+"</li>";r+="</ul>",a(".h-indicator").append(r)}g.arrow&&(h.append('<span class="h-arrow"></span>'),a(h[p-1]).find(".h-arrow").remove())})}(Zepto);