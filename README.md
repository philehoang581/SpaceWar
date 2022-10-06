# SpaceWar
War Space


private IEnumerator ScalePenal()
    {
        penal.transform.localScale = Vector3.zero;
        float a;

        float timeshow = 0;
        while (timeshow<=3)
        {
            yield return new WaitForEndOfFrame();

            timeshow -= Time.deltaTime;
            penal.transform.localScale = new Vector3(1, 1, 1) * (timeshow/3);
        }
        penal.transform.localScale = Vector3.one;
       //..
    }
