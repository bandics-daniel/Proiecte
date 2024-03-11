t=Bandics(:,1);
u=Bandics(:,2);
y=Bandics(:,3);
x=Bandics(:,4);

figure
plot(t,u,t,y)
legend('u','y')
title('Raspunsul unui ciruit electric', 'la o intrare de tip sinus cu amplitudine constanta si frecventa variabila')

i2=428;
i1=425;
i4=439;
i3=435;

Mr = (y(i2)-y(i4))/(u(i1)-u(i3)) 
Tr = (t(i4) - t(i2))*2 

zeta = sqrt((Mr-sqrt(Mr^2-1))/2/Mr) 
wr = (2*pi/Tr) 
wn = wr/sqrt(1-2*zeta^2) 
K = mean(y)/mean(u) 

Hs = tf(K*wn^2,[1 2*zeta*wn wn^2])

A = [0,1;-wn^2,-2*zeta*wn]; 
B = [0;K*wn^2]; 
C = [1,0]; 
D = 0; 

sys = ss(A,B,C,D);
ysim1 = lsim(sys,u,t,[y(1),(y(2)-y(1))/(t(2)-t(1))]);

J = 1/sqrt(length(t))*norm(y-ysim1) 
empn = norm(y-ysim1)/norm(y-mean(y))*100 


figure
plot(t,ysim1,t,y)
legend('Iesirea simulata','y')
hold on

%% identificare arx -> Metoda celor mai mici patrate
Te = t(2)-t(1);
i5=87;
i6=668;
data_id = iddata(y(i5:i6),u(i5:i6),Te);

m_armax=armax(data_id,[2,2,2,1])
figure,resid(data_id,m_armax)
figure,compare(data_id,m_armax)

Hz_armax = tf(m_armax)
Hs_armax = d2c(Hz_armax,'zoh')
zpk(Hs_armax)

%% identificare oe -> Metoda erorii de iesire
nF=2; 
nB=2; 
nd=1; 
m_oe = oe(data_id,[nB,nF,nd])

figure
resid(m_oe,data_id);

figure
compare(m_oe,data_id);

Hz_oe = tf(m_oe)
Hs_oe = d2c(Hz_oe,'zoh')
zpk(Hs_oe)
